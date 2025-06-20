﻿document.addEventListener("DOMContentLoaded", function () {
    const params = new URLSearchParams(window.location.search);
    const status = params.get("status");

    const botoesFiltro = document.querySelectorAll('.btn-filtro');

    for (const btn of botoesFiltro) {
        const href = btn.getAttribute('href') || "";

        if (
            (status === null && !href.includes("status=")) ||
            (status === "pendentes" && href.includes("status=pendentes")) ||
            (status === "concluidas" && href.includes("status=concluidas")) ||
            (status === "prioridades" && href.includes("status=prioridades"))
        ) {
            btn.classList.remove('btn-outline-primary');
            btn.classList.add('btn-primary');
        } else {
            btn.classList.remove('btn-primary');
            btn.classList.add('btn-outline-primary');
        }
    }
});