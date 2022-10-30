const { getAll, create, getById, deleteById, joinTrip, update, getBuddies, getTripAndUsers } = require('../services/tripService');
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
    if(trip.creator == req.user._id){
        trip.isCreator = true;
    }else if (trip.buddies) {
        if(trip.buddies.map(b => b.toString()).includes(req.user._id.toString())){
            trip.hasJoined = true;
        }
        if(trip.seats > 0){
            trip.hasSeats = true;
        }
    }
    const triplaino = await getTripAndUsers(req.params.id)
    trip.buddiesList = triplaino.buddies.map(b => b.email).join(', ');

    // trip.buddiesList = await getBuddies(req.params.id);
    // console.log(trip.buddiesList);
    // trip.buddiesList = trip.buddiesList.map(b => b.email)
    // console.log(trip.buddiesList);

    res.render('trip-details', {
        title: 'Trip Details',
        trip: Object.assign(trip, { creator: req.user.email})
    })
})

tripsController.get('/:id/join', async (req, res) => {
    const trip = await getById(req.params.id);

    try {
        if(trip.creator == req.user._id){
            trip.isCreator = true;
            throw new Error('Cannot join your own trip');
        }
        if(trip.seats == 0){
            trip.hasSeats = false;
            throw new Error('There are no seats available');
        }
        if(trip.buddies.map(b => b.toString()).includes(req.user._id.toString())){
            trip.hasJoined = true;
            throw new Error('Cannot join twice');
        }

        await joinTrip(req.params.id, req.user._id);
        res.redirect(`/trips/${req.params.id}/details`)
    } catch (error) {
        res.redirect(`/trips/${req.params.id}/details`, {
            title: 'Trip Details',
            trip,
            errors: parseError(error)
        })
    }
})

tripsController.get('/:id/delete', async (req, res) => {
    const trip = await getById(req.params.id);

    if (trip.creator != req.user._id) {
        return res.redirect('/auth/login');
    }

    await deleteById(req.params._id);
    res.redirect('/trips/shared');
})

tripsController.get('/:id/edit', async (req, res) => {
    const trip = await getById(req.params.id);

    if(trip.creator != req.user._id){
        return res.redirect('/auth/login')
    }

    res.render('trip-edit', {
        title: 'Edit Trip',
        trip
    })
})

tripsController.post('/:id/edit', async (req, res) => {
    const trip = await getById(req.params.id);

    if(trip.creator != req.user._id){
        return res.redirect('/auth/login')
    }

    const edited = {
        startPoint: req.body.startPoint,
        endPoint: req.body.endPoint,
        date: req.body.date,
        time: req.body.time,
        carImage: req.body.carImage,
        carBrand: req.body.carBrand,
        seats: req.body.seats,
        price: req.body.price,
        description: req.body.description
    }

    try {
        if (Object.values(edited).some(v => !v)) {
            throw new Error('All fields are required');
        }

        await update(req.params.id, edited);
        res.redirect(`/trips/${req.params.id}/details`)
    } catch (error) {
        res.render('trip-edit',{
            title: 'Edit Trip',
            trip: Object.assign(edited, { _id: req.params.id}),
            errors: parseError(error)
        })
    }
})

module.exports = tripsController;