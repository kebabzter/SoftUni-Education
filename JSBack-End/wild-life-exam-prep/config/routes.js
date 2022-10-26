const authController = require("../controllers/authController");
const homeController = require("../controllers/homeController");
const postsController = require("../controllers/postsController");

module.exports = (app) => {
    app.use('/', homeController);
    app.use('/auth', authController);
    app.use('/posts', postsController)
};