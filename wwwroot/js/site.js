// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
function limpaOpcoesAbertas() {
    let nodes = document.querySelectorAll(".barra .esquerda .link div");

    nodes.forEach(n => n.classList.remove('is-active'));
}
*/

document.querySelector("#inf-link").addEventListener('click', (e) => {
    e.preventDefault();
    if (document.querySelector("#contatos").classList.contains('is-active')) {
        document.querySelector("#contatos").classList.remove('is-active');
    }

    document.querySelector("#informacao").classList.toggle("is-active");

}); 


document.querySelector("#cont-link").addEventListener('click', (e) => {
    e.preventDefault();
    if (document.querySelector("#informacao").classList.contains('is-active')) {
        document.querySelector("#informacao").classList.remove('is-active');
    }

    document.querySelector("#contatos").classList.toggle("is-active");

});