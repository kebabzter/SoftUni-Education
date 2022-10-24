const { getAll, create, getById } = require('../services/tripService');
const { parseError } = require('../util/parser');


const tripsController = require('express').Router();

tripsController.get('/shared', async (req, res) => {
    const trips = await getAll();
    res.render('shared-trips', {
        title: 'Shared Trips',
        trips
    })
});

tripsController.get('/create', (req, res) => {
    res.render('trip-create', {
        title: 'Create Trip'
    });
});

tripsController.post('/create', async (req, res) => {
    const trip = {
        startPoint: req.body.startPoint,
        endPoint: req.body.endPoint,
        date: req.body.date,
        time: req.body.time,
        carImage: req.body.carImage,
        carBrand: req.body.carBrand,
        seats: req.body.seats,
        price: req.body.price,
        description: req.body.description,
        creator: req.user._id
    }

    try{
        if (Object.values(trip).some(v => !v)) {
            throw new Error('All fields are required');
        }

        await create(trip);
        res.redirect('/trips/shared');
    }
    catch(error){
        res.render('trip-create', {
            title: 'Create Trip',
            body: trip,
            errors: parseError(error)
        })
    }
});

tripsController.get('/:id/details', async (req, res) => {
    const trip = await getById(req.params.id);
    console.log(trip);
    if(trip.creator == req.user._id){
        trip.isCreator = true;
    }

    res.render('trip-details', {
        title: 'Trip Details',
        trip: Object.assign(trip, { creator: req.user.email})
    })
})

module.exports = tripsController;