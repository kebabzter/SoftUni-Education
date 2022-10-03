import { html } from '../lib.js';
import { login } from '../api/users.js'

const loginTemplate = (onSubmit) => html`
<section id="login-page" class="auth">
            <form @submit=${onSubmit} id="login">
                <h1 class="title">Login</h1>

                <article class="input-group">
                    <label for="login-email">Email: </label>
                    <input type="email" id="login-email" name="email">
                </article>

                <article class="input-group">
                    <label for="password">Password: </label>
                    <input type="password" id="password" name="password">
                </article>

                <input type="submit" class="btn submit-btn" value="Log In">
            </form>
        </section>`;

export function loginView(ctx){
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(ev){
        ev.preventDefault();
        const formData = new FormData(ev.target);

        const email = formData.get('email').trim();
        const password = formData.get('password').trim();
        
        if (email == '' || password == '') {
            return alert('All fields are required!');
        }
        

        await login(email,password );
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}