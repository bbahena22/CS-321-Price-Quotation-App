// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const scrollPositionKey = "cs321-scroll-position";

if ("scrollRestoration" in history) {
	history.scrollRestoration = "manual";
}

function saveScrollPosition() {
	sessionStorage.setItem(scrollPositionKey, window.scrollY.toString());
}

function restoreScrollPosition() {
	const savedPosition = sessionStorage.getItem(scrollPositionKey);

	if (savedPosition !== null) {
		window.scrollTo(0, Number.parseInt(savedPosition, 10));
		sessionStorage.removeItem(scrollPositionKey);
	}
}

restoreScrollPosition();
document.addEventListener("DOMContentLoaded", restoreScrollPosition, { once: true });
window.addEventListener("pageshow", restoreScrollPosition, { once: true });

document.addEventListener("submit", saveScrollPosition);

document.addEventListener("click", (event) => {
	const link = event.target.closest("a");

	if (link?.classList.contains("btn-clear")) {
		saveScrollPosition();
	}
});
