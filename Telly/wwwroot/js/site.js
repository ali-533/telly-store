// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

// Cart Management using localStorage
document.addEventListener("DOMContentLoaded", function () {
    updateCartUI();

    // 1. Add TV to Cart from Details Modal
    const addTvBtn = document.getElementById('addToCartBtn');
    if (addTvBtn) {
        addTvBtn.addEventListener('click', function () {
            const name = document.getElementById('modalTvName').textContent;
            const priceText = document.getElementById('modalTvPrice').textContent;
            const image = document.getElementById('modalTvImage').src;
            const price = parseFloat(priceText.replace('$', '')) || 0.00;

            addToCart({ id: 'tv-' + name, name: name, price: price, image: image });

            // Close modal
            const modalEl = document.getElementById('tvModal');
            const modal = bootstrap.Modal.getInstance(modalEl);
            if (modal) modal.hide();
        });
    }

    // 2. Add Accessory to Cart from Accessories Page
    document.querySelectorAll('.add-accessory-btn').forEach(button => {
        button.addEventListener('click', function () {
            const id = this.getAttribute('data-id');
            const name = this.getAttribute('data-name');
            const price = parseFloat(this.getAttribute('data-price')) || 25.00;
            const image = this.getAttribute('data-image');

            addToCart({ id: id, name: name, price: price, image: image });
        });
    });
});

function getCart() {
    return JSON.parse(localStorage.getItem('tellyCart')) || [];
}

function saveCart(cart) {
    localStorage.setItem('tellyCart', JSON.stringify(cart));
    updateCartUI();
}

function addToCart(item) {
    let cart = getCart();
    let existing = cart.find(i => i.id === item.id);
    if (existing) {
        existing.quantity += 1;
    } else {
        item.quantity = 1;
        cart.push(item);
    }
    saveCart(cart);
}

function updateQuantity(id, change) {
    let cart = getCart();
    let item = cart.find(i => i.id === id);
    if (item) {
        item.quantity += change;
        if (item.quantity <= 0) {
            cart = cart.filter(i => i.id !== id);
        }
    }
    saveCart(cart);
}

function updateCartUI() {
    let cart = getCart();
    let totalCount = cart.reduce((sum, item) => sum + item.quantity, 0);

    // Update Navbar Badge Counter
    const badge = document.getElementById('cartBadge');
    if (badge) {
        if (totalCount > 0) {
            badge.textContent = totalCount;
            badge.style.display = 'inline-block';
        } else {
            badge.style.display = 'none';
        }
    }

    // Update Cart Modal Content
    const modalBody = document.getElementById('cartModalBody');
    const cartTotalEl = document.getElementById('cartTotal');
    const emptyBtn = document.getElementById('emptyCartRedirectBtn');
    const checkoutBtn = document.getElementById('proceedCheckoutBtn'); // <--- Added reference

    if (!modalBody) return;

    if (cart.length === 0) {
        modalBody.innerHTML = `
            <div class="text-center py-4">
                <p class="text-muted fs-5 mb-2">Your cart is currently empty.</p>
                <small class="text-muted">Add items from the store catalog to get started.</small>
            </div>`;
        if (cartTotalEl) cartTotalEl.textContent = '$0.00';
        if (emptyBtn) emptyBtn.style.display = 'inline-block';
        if (checkoutBtn) checkoutBtn.style.display = 'none'; // Hide checkout when empty
        return;
    }

    if (emptyBtn) emptyBtn.style.display = 'none';
    if (checkoutBtn) checkoutBtn.style.display = 'inline-block'; // Show checkout when items exist

    let html = '<div class="list-group list-group-flush">';
    let totalPrice = 0;

    cart.forEach(item => {
        let itemTotal = item.price * item.quantity; // Fixed typo here
        totalPrice += itemTotal;

        html += `
            <div class="list-group-item d-flex align-items-center justify-content-between py-3">
                <div class="d-flex align-items-center">
                    <img src="${item.image}" class="rounded me-3 object-fit-contain" style="width: 50px; height: 50px;" alt="${item.name}">
                    <div>
                        <h6 class="mb-0 fw-bold">${item.name}</h6>
                        <small class="text-muted">$${item.price.toFixed(2)} each</small>
                    </div>
                </div>
                <div class="d-flex align-items-center">
                    <div class="input-group input-group-sm me-3" style="width: 100px;">
                        <button class="btn btn-outline-secondary" type="button" onclick="updateQuantity('${item.id}', -1)">-</button>
                        <input type="text" class="form-control text-center bg-white" value="${item.quantity}" readonly>
                        <button class="btn btn-outline-secondary" type="button" onclick="updateQuantity('${item.id}', 1)">+</button>
                    </div>
                    <span class="fw-bold text-danger" style="width: 75px; text-align: right;">$${itemTotal.toFixed(2)}</span>
                </div>
            </div>`;
    });

    html += '</div>';
    modalBody.innerHTML = html;
    if (cartTotalEl) cartTotalEl.textContent = `$${totalPrice.toFixed(2)}`;
}