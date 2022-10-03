import { postsByUserId } from '../api/posts.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js'


const userPostsTemplate = (posts) => html`
<section id="my-posts-page">
    <h1 class="title">My Posts</h1>
        <div class="my-posts">
        ${posts.length == 0 
        ? html`<h1 class="title no-posts-title">You have no posts yet!</h1>` 
        : posts.map(postCard)}
        </div>
</section>`;

const postCard = (post) => html `
            <div class="post">
                <h2 class="post-title">${post.title}</h2>
                    <img class="post-image" src=${post.imageUrl} alt="Kids clothes">
                <div class="btn-wrapper">
                    <a class="details-btn btn" href="/details/${post._id}">Details</a>
                </div>
            </div>`;

export async function userPostsView(ctx){
    const userData = getUserData();
    const posts = await postsByUserId(userData.id);
    ctx.render(userPostsTemplate(posts));
}