// Hero particles background (lightweight)
const canvas = document.getElementById("heroParticles");
if (canvas) {
  const ctx = canvas.getContext("2d");
  let particles = [];
  let width, height;

  function resize() {
    width = canvas.offsetWidth;
    height = canvas.offsetHeight;
    canvas.width = width;
    canvas.height = height;
  }

  function createParticles() {
    const count = Math.floor((width * height) / 25000);
    particles = [];
    for (let i = 0; i < count; i++) {
      particles.push({
        x: Math.random() * width,
        y: Math.random() * height,
        r: Math.random() * 1.6 + 0.4,
        dx: (Math.random() - 0.5) * 0.3,
        dy: (Math.random() - 0.5) * 0.3,
        alpha: Math.random() * 0.7 + 0.3,
      });
    }
  }

  function draw() {
    ctx.clearRect(0, 0, width, height);
    ctx.fillStyle = "#ffffff";
    particles.forEach((p) => {
      ctx.globalAlpha = p.alpha;
      ctx.beginPath();
      ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
      ctx.fill();

      p.x += p.dx;
      p.y += p.dy;

      if (p.x < -5) p.x = width + 5;
      if (p.x > width + 5) p.x = -5;
      if (p.y < -5) p.y = height + 5;
      if (p.y > height + 5) p.y = -5;
    });
    requestAnimationFrame(draw);
  }

  window.addEventListener("resize", () => {
    resize();
    createParticles();
  });

  resize();
  createParticles();
  draw();
}

// Scroll reveal animations
const animatedEls = document.querySelectorAll("[data-animate]");
if ("IntersectionObserver" in window) {
  const observer = new IntersectionObserver(
    (entries) => {
      entries.forEach((entry) => {
        if (entry.isIntersecting) {
          entry.target.classList.add("visible");
          observer.unobserve(entry.target);
        }
      });
    },
    {
      threshold: 0.15,
    }
  );

  animatedEls.forEach((el) => observer.observe(el));
} else {
  animatedEls.forEach((el) => el.classList.add("visible"));
}

// Parallax on hero orbit card
const orbitCard = document.querySelector(".hero-orbit");
if (orbitCard) {
  const strength = 15;
  orbitCard.addEventListener("mousemove", (e) => {
    const rect = orbitCard.getBoundingClientRect();
    const x = ((e.clientX - rect.left) / rect.width - 0.5) * 2;
    const y = ((e.clientY - rect.top) / rect.height - 0.5) * 2;
    orbitCard.style.transform = `translateY(-2px) rotateX(${y * -strength}deg) rotateY(${
      x * strength
    }deg)`;
  });
  orbitCard.addEventListener("mouseleave", () => {
    orbitCard.style.transform = "translateY(0) rotateX(0) rotateY(0)";
  });
}

// Mobile navigation toggle
const navToggle = document.querySelector(".nav-toggle");
const navLinks = document.querySelector(".nav-links");
if (navToggle && navLinks) {
  navToggle.addEventListener("click", () => {
    navLinks.classList.toggle("open");
  });
  navLinks.querySelectorAll("a").forEach((link) =>
    link.addEventListener("click", () => {
      navLinks.classList.remove("open");
    })
  );
}

// Testimonial slider
const testimonialCards = document.querySelectorAll(".testimonial-card");
const dots = document.querySelectorAll(".testimonial-controls .dot");

function showTestimonial(index) {
  testimonialCards.forEach((card, i) => {
    card.classList.toggle("active", i === index);
  });
  dots.forEach((dot, i) => {
    dot.classList.toggle("active", i === index);
  });
}

if (testimonialCards.length && dots.length) {
  dots.forEach((dot, index) => {
    dot.addEventListener("click", () => showTestimonial(index));
  });

  let current = 0;
  setInterval(() => {
    current = (current + 1) % testimonialCards.length;
    showTestimonial(current);
  }, 8000);
}

// Footer year
const yearEl = document.getElementById("year");
if (yearEl) {
  yearEl.textContent = new Date().getFullYear();
}
