document.addEventListener("DOMContentLoaded", function () {
    const enderecoAtual = window.location.pathname.toLowerCase();
    const linksNavbar = document.querySelectorAll('.navbar-nav .nav-link');

    for (const link of linksNavbar) {
        const atributoHref = link.getAttribute('href').toLowerCase();

        if (enderecoAtual === atributoHref || enderecoAtual.startsWith(atributoHref + "/")) {
            link.classList.remove('nav-link-default');
            link.classList.add('nav-link-ativo');
        } else {
            link.classList.remove('nav-link-ativo');
            link.classList.add('nav-link-default');
        }
    }
});
