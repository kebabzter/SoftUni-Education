import { getAllPosts } from '../api/posts.js';
import { html } from '../lib.js';


const homeTemplate = (posts) => html`
<section id="dashboard-page">
    <h1 class="title">All Posts</h1>
        <div class="all-posts">
        ${posts.length == 0 
        ? html`<h1 class="title no-posts-title">No posts yet!</h1>` 
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

export async function homeView(ctx){
    const posts = await getAllPosts();

    ctx.render(homeTemplate(posts));
}