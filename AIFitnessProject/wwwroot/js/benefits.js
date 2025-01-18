document.querySelectorAll('.benefit-question').forEach(button => {
    button.addEventListener('click', () => {
        const benefitItem = button.parentElement;

        document.querySelectorAll('.benefit-item').forEach(item => {
            if (item !== benefitItem) {
                item.classList.remove('active');
            }
        });

        benefitItem.classList.toggle('active');
    });
});
