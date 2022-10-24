const Trip = require("../models/Trip");
const User = require("../models/User");

async function getAll(){
    return Trip.find({}).lean();
}
async function getById(id){
    return Trip.findById(id).lean();
}
async function getAllByUserId(userId){
    return Trip.find({ buddies: userId}).lean();
}
async function create(trip){
    return await Trip.create(trip);
}
async function update(id, trip){
    const existing = await Trip.findById(id)

    existing.startPoint = trip.startPoint;
    existing.endPoint = trip.endPoint;
    existing.date = trip.date;
    existing.time = trip.time;
    existing.carImage = trip.carImage;
    existing.carBrand = trip.carBrand;
    existing.seats = trip.seats;
    existing.price = trip.price;
    existing.description = trip.description;

    await existing.save();
}
async function deleteById(id){
    await Trip.findByIdAndRemove(id)
}

module.exports = {
    getAll,
    getAllByUserId,
    create,
    deleteById,
    update,
    getById,
}
