<script>
    // HTML yüklendikten sonra işlemleri gerçekleştir
    document.addEventListener('DOMContentLoaded', function() {
        // Hover efekti için gerekli olay dinleyicilerini tanımla
        document.querySelector('.badge-warning').addEventListener('mouseenter', function () {
            document.querySelector('.cart-items').style.display = 'block';
        });

    document.querySelector('.badge-warning').addEventListener('mouseleave', function() {
        document.querySelector('.cart-items').style.display = 'none';
        });
    });
</script>
