const { hasUser } = require('../middlewares/guards');
const { getByOwnerId, getFollowedByUser } = require('../services/blogService');

const profileController = require('express').Router();

profileController.get('/', hasUser(), async(req, res) => {
    const userId = req.user._id

    const createdBlogs = await getByOwnerId(userId);
    const followedBlogs = await getFollowedByUser(userId)

    res.render('profile', {
        title: 'Profile',
        body: {
            createdBlogs,
            followedBlogs,
            email: res.locals.email
        },
    })
})

module.exports = profileController;