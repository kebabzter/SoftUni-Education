import { donationByUser, donationsCount, makeDonation } from '../api/donations.js';
import { deletePost, getPostById } from '../api/posts.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';


const detailsTemplate = (post, isLogged,isOwner, onDelete, onDonate) => html`
<section id="details-page">
            <h1 class="title">Post Details</h1>

            <div id="container">
                <div id="details">
                    <div class="image-wrapper">
                        <img src=${post.imageUrl} alt="Material Image" class="post-image">
                    </div>
                    <div class="info">
                        <h2 class="title post-title">${post.title}</h2>
                        <p class="post-description">Description: ${post.description}</p>
                        <p class="post-address">Address: ${post.address}</p>
                        <p class="post-number">Phone number: ${post.phone}</p>
                        <p class="donate-Item">Donate Materials: 0</p>

                        <div class="btns">
                            ${isOwner ? html `
                            <a class="edit-btn btn" href="/edit/${post._id}">Edit</a>
                            <button @click=${onDelete} class="delete-btn btn">Delete</button>
                            ` : ''}
                            ${isLogged && !isOwner?  html`<a @click=${onDonate} class="donate-btn btn">Donate</a>` : ''}
                        </div>
                    </div>
                </div>
            </div>
    </section>`;


export async function detailsView(ctx){
    const post = await getPostById(ctx.params.id);
    const userData = getUserData();
    // const countOfDonations = await donationsCount(ctx.params.id);
    // const hasDonated = await donationByUser(ctx.params.id, userData.id) == 0 ? false : true;
    const isLogged = userData ? true : false;
    const isOwner = userData?.id == post._ownerId;
    ctx.render(detailsTemplate(post, isLogged, isOwner, onDelete, onDonate));

    async function onDelete(){
        const choice = confirm('Are you sure you want to delete this post?')

        if (choice) {
            await deletePost(ctx.params.id);
            ctx.page.redirect('/');
        }
    }

    async function onDonate(){
        await makeDonation(ctx.params.id);
        ctx.render(detailsTemplate(post, isLogged, isOwner, onDelete, onDonate, countOfDonations, hasDonated));
    }
}