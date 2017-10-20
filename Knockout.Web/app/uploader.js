define(['service', 'uuid4'], function (service, uuid4) {

    return (function () {
        var self = this;

        self.id = uuid4.newGuid();
        self.isUpload = ko.observable(false);
        self.percentage = ko.observable(0);
        self.isUploadEnabled = ko.observable(true);
        self.isEOF = false;
        self.file = ko.observable(null);
        self.fileSize = ko.observable(0);

        self.offset = ko.observable(0);
        self.chunkSize = 65536;
        self.binary = true;

        self.percentageText = ko.computed(function () {
            return Number(self.percentage()) + '%';
        }, self);

        self.remainingText = ko.computed(function () {
            return 'Uploaded: ' + parseFloat(self.offset() / 1024).toFixed(2) + ' / ' + parseFloat(self.fileSize() / 1024).toFixed(2) + ' kb';
        }, self);
        
        self.uploadFile = function () {
            self.isUpload(true);
            self.percentage(0);
            self.fileSize(self.file().size);
            //Start new message
            service.postMessage(self.id, 0, self.fileSize(), null).then(function (data) {
                // Start uploading data block-by-block from the begining
                uploadChunks();
            });
        }

        function uploadChunks () {
            readFileChunk().then(function (data) {
                if (data != null) {
                    // POST chunk of data to server
                    service.postMessage(self.id, 1, data.length, data).then(function () {
                        // Read next chunk
                        var percentage = Math.floor((self.offset() / self.fileSize()) * 100);
                        self.percentage(percentage);
                        uploadChunks();
                    }).fail(function (err) {
                        console.log(err);
                    });
                } else {
                    // Mark end of data
                    service.postMessage(self.id, 2, 0, null);
                    // Reset data for the next upload
                    self.id = uuid4.newGuid();
                    self.offset(0);
                    self.isUpload(false);
                    self.file(null);
                    self.fileSize(0);
                }
            }, function (err) {
                console.log(err);
            });
        }

        function readFileChunk () {
            return new Promise((resolve, reject) => {
                if (self.offset() >= self.fileSize()) {
                    self.percentage(100);
                    resolve(null);
                    return
                }

                function onLoadEndHandler (evt) {
                    if (evt.target.error == null) {
                        var arrayFormatted = new Uint8Array(evt.target.result);
                        resolve(arrayFormatted);
                    } else {
                        reject(evt.target.error);
                    }
                }

                var r = new FileReader();
                //console.log('Reading chunk ' + self.offset() + ' to ' + Number(self.offset() + self.chunkSize) + ' of ' + self.file().size);
                var blob = self.file().slice(self.offset(), self.offset() + self.chunkSize);
                
                self.offset(self.offset() + self.chunkSize);
                if (self.offset() > self.fileSize()) {
                    self.offset(self.fileSize());
                }

                r.onloadend = onLoadEndHandler;
                if (self.binary) {
                    r.readAsArrayBuffer(blob);
                } else {
                    r.readAsText(blob);
                }
            });
        }

        ko.bindingHandlers.fileUpload = {
            init: function (element, valueAccessor) {
                $(element).change(function () {
                    valueAccessor()(element.files[0]);
                });
            },
            update: function (element, valueAccessor) {
                if (ko.unwrap(valueAccessor()) === null) {
                    $(element).wrap('<form>').closest('form').get(0).reset();
                    $(element).unwrap();
                }
            }
        };

        return {
            isUpload: self.isUpload,
            uploadFile: self.uploadFile,
            percentage: self.percentage,
            percentageText: self.percentageText,
            remainingText: self.remainingText,
            isUploadEnabled: self.isUploadEnabled
        }
    }());

});
