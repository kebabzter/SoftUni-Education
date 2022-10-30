const authController = require("../controllers/authController");
const blogController = require("../controllers/blogController");
const homeController = require("../controllers/homeController");
const profileController = require("../controllers/profileController");

module.exports = (app) => {
    app.use('/', homeController);
    app.use('/auth', authController);
    app.use('/blogs', blogController);
    app.use('/profile', profileController);

    app.all('/*', (req, res) => {
        res.render('404');
    })
};