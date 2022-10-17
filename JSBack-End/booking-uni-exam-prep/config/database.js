const mongoose = require('mongoose');

// TODO change database according to assignment
const CONNECTION_STRING = 'mongodb://localhost:27017/booking-uni'

module.exports = async (app) => {
    try {
        await mongoose.connect(CONNECTION_STRING, {
            useNewUrlParser: true,
            useUnifiedTopology: true
        });
        console.log('Database connected');

    } catch (error) {
        console.error(error.message);
        process.exit(1);   
    }
};