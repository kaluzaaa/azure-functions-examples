var Jimp = require("jimp");

module.exports = (context, myBlob) => {
    Jimp.read(myBlob).then((image) => {
        image
            .resize(600, Jimp.AUTO) 
            .greyscale()
            .getBuffer(Jimp.MIME_JPEG, (error, stream) => {
                if (error) {
                    context.log(`There was an error processing the image.`);
                    context.done(error);
                }
                else {
                    context.log(`Successfully processed the image`);
                    context.done(null, stream);
                }
            });
    });
};