const {Schema, Types ,model} = require('mongoose');

const URL_PATTERN = /^https?:\/\/.+$/i

const tripSchema = new Schema({
    startPoint: {type: String, required: true},
    endPoint: {type: String, required: true},
    date: {type: String, required: true},
    time: {type: String, required: true},
    carImage: {type : String, required: true, validate: {
        validator: (value) => URL_PATTERN.test(value),
        message: 'Car image URL is not valid'
    }},
    carBrand: {type: String, required: true},
    seats: {type: Number, required: true},
    price: {type: Number, required: true},
    description: {type: String, required: true},
    creator: {type: Types.ObjectId, ref: 'User', required: true},
    buddies: {type: [Types.ObjectId], ref: 'User', default: [] },
});

const Trip = model('Trip', tripSchema);

module.exports = Trip;