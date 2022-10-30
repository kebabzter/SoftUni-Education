function hasUser() {
    return (req, res, next) => {
        if(req.user){
            next();
        } else{
            res.render('/auth/login')
        }
    };
}

function isGuest(){
    return (req, res, next) => {
        if(req.user){
            res.render('/auth/login')
        } else{
            next();
        }
    };
}

module.exports = {
    hasUser,
    isGuest
}