const carousel = document.querySelector('.carousel');
        let currentIndex = 0;

        function slide() {
            currentIndex = (currentIndex + 1) % 3; // Assuming 3 images
            const translateValue = -currentIndex * 100;
            carousel.style.transform = `translateX(${translateValue}%)`;
        }

        setInterval(slide, 3000); // Change image every 3 seconds