// ═══════════════════════════════════════════
//   NOTIFICATION SYSTEM — notify.js
//   Uso: notify.toast / notify.banner
// ═══════════════════════════════════════════

const notify = (() =>
{

    // ── Iconos por tipo ──────────────────────
    const icons = {
        success: 'bi-check2-circle',
        error: 'bi-x-circle',
        warning: 'bi-exclamation-triangle',
        info: 'bi-info-circle'
    };

    // ── Títulos por defecto ──────────────────
    const defaultTitles = {
        success: 'Completado',
        error: 'Error',
        warning: 'Atención',
        info: 'Información'
    };

    // ── Asegurar contenedor toast ────────────
    function getToastContainer()
    {
        let c = document.getElementById('toast-container');
        if (!c)
        {
            c = document.createElement('div');
            c.id = 'toast-container';
            document.body.appendChild(c);
        }
        return c;
    }

    // ── Asegurar contenedor banner ───────────
    function getBannerContainer()
    {
        let c = document.getElementById('banner-container');
        if (!c)
        {
            // intentar insertarlo justo después del topbar
            c = document.createElement('div');
            c.id = 'banner-container';
            const main = document.getElementById('mainContent');
            if (main) main.prepend(c);
            else document.body.prepend(c);
        }
        return c;
    }

    // ── Remover con animación ────────────────
    function removeEl(el)
    {
        el.classList.add('removing');
        el.addEventListener('animationend', () => el.remove(), { once: true });
    }

    // ════════════════════════════════════════
    //  TOAST
    //  notify.toast({ type, title, message, duration })
    //  type: 'success' | 'error' | 'warning' | 'info'
    // ════════════════════════════════════════
    function toast({ type = 'info', title, message = '', duration = 4000 } = {})
    {
        const container = getToastContainer();
        const resolvedTitle = title || defaultTitles[type];

        const el = document.createElement('div');
        el.className = `toast-item toast-${type}`;
        el.innerHTML = `
            <div class="toast-icon"><i class="bi ${icons[type]}"></i></div>
            <div class="toast-body">
                <p class="toast-title">${resolvedTitle}</p>
                ${message ? `<p class="toast-message">${message}</p>` : ''}
            </div>
            <button class="toast-close" title="Cerrar"><i class="bi bi-x"></i></button>
            <div class="toast-progress" style="animation-duration: ${duration}ms;"></div>
        `;

        el.querySelector('.toast-close').addEventListener('click', () => removeEl(el));
        container.appendChild(el);

        if (duration > 0) setTimeout(() => { if (el.isConnected) removeEl(el); }, duration);
        return el;
    }

    // ════════════════════════════════════════
    //  BANNER
    //  notify.banner({ type, message, duration })
    //  duration: 0 = permanente hasta cerrar
    // ════════════════════════════════════════
    function banner({ type = 'info', message = '', duration = 6000 } = {})
    {
        const container = getBannerContainer();

        const el = document.createElement('div');
        el.className = `banner-item banner-${type}`;
        el.innerHTML = `
            <i class="bi ${icons[type]} banner-icon"></i>
            <span class="banner-text">${message}</span>
            <button class="banner-close" title="Cerrar"><i class="bi bi-x"></i></button>
        `;

        el.querySelector('.banner-close').addEventListener('click', () => removeEl(el));
        container.appendChild(el);

        if (duration > 0) setTimeout(() => { if (el.isConnected) removeEl(el); }, duration);
        return el;
    }

    // ── Shortcuts ───────────────────────────
    toast.success = (message, title) => toast({ type: 'success', message, title });
    toast.error = (message, title) => toast({ type: 'error', message, title });
    toast.warning = (message, title) => toast({ type: 'warning', message, title });
    toast.info = (message, title) => toast({ type: 'info', message, title });

    banner.success = (message, duration = 1000) => banner({ type: 'success', message, duration });
    banner.error = (message) => banner({ type: 'error', message });
    banner.warning = (message) => banner({ type: 'warning', message });
    banner.info = (message) => banner({ type: 'info', message });

    return { toast, banner };
})();