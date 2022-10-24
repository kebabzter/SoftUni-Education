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

async function joinTrip(tripId, userId){
    const trip = await Trip.findById(tripId)
    const user = await User.findById(userId)

    user.tripsHistory.push(tripId)
    trip.buddies.push(userId);
    trip.seats--;
    await user.save();
    await trip.save();
}

// async function getBuddies(tripId){
//     const trip = await getById(tripId)
//     const buddieList = [];
//     for (let index = 0; index < trip.buddies.length; index++) {
//         const user = User.findById(trip.buddies[index]).lean()
//         buddieList.push(user)
//     }
//     return buddieList;
// }

async function getTripAndUsers(id){
    return Trip.findById(id).populate('creator').populate('buddies').lean();
}

module.exports = {
    getAll,
    getAllByUserId,
    create,
    deleteById,
    update,
    getById,
    joinTrip,
    getTripAndUsers
    // getBuddies
}
