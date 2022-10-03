import { logout } from './api/users.js';
import { page, render} from './lib.js';
import { getUserData } from './util.js';
import { createView } from './views/create.js';
import { dashboardView } from './views/dashboard.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';

const main = document.querySelector('main');

document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', homeView);
page('/login', loginView)
page('/register', registerView)
page('/dashboard', dashboardView)
page('/create', createView)
page('/edit/:id', editView)
page('/details/:id', detailsView)


// Start application
updateNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;
    
    next();
};

function renderMain(templateResult) {
    render(templateResult, main);
};

function updateNav() {
    const userData = getUserData();
    
    if (userData) {
        document.querySelectorAll('.user').forEach(x => x.style.display = 'block');
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'none');
    } else {
        document.querySelectorAll('.user').forEach(x => x.style.display = 'none');
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'block');
    }
};

function onLogout() {
    logout();
    updateNav();
    page.redirect('/');
}