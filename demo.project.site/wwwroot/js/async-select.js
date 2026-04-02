// ═══════════════════════════════════════════
//   ASYNC SELECT — async-select.js
//   Uso: AsyncSelect.init(el, options)
// ═══════════════════════════════════════════

const AsyncSelect = (() =>
{

    // ── Init desde atributos HTML ────────────
    function initAll()
    {
        document.querySelectorAll('[data-async-select]').forEach(el =>
        {
            init(el, {
                url: el.dataset.url,
                placeholder: el.dataset.placeholder || 'Seleccione una opción',
                searchPlaceholder: el.dataset.searchPlaceholder || 'Buscar...',
                valueField: el.dataset.valueField || 'value',
                labelField: el.dataset.labelField || 'text',
                // params extra opcionales: data-params='{"areaId": 1}'
                params: el.dataset.params ? JSON.parse(el.dataset.params) : {}
            });
        });
    }

    // ── Init individual ──────────────────────
    function init(nativeSelect, options = {})
    {
        const {
            url,
            placeholder = 'Seleccione una opción',
            searchPlaceholder = 'Buscar...',
            valueField = 'value',
            labelField = 'text',
            params = {}
        } = options;

        if (!url) { console.warn('AsyncSelect: falta data-url en', nativeSelect); return; }

        nativeSelect.classList.add('aselect-native');

        // ── Construir DOM ──────────────────
        const wrapper = document.createElement('div');
        wrapper.className = 'aselect-wrapper';
        nativeSelect.parentNode.insertBefore(wrapper, nativeSelect);
        wrapper.appendChild(nativeSelect);

        const trigger = document.createElement('div');
        trigger.className = 'aselect-trigger';
        trigger.setAttribute('tabindex', '0');
        trigger.setAttribute('role', 'combobox');
        trigger.setAttribute('aria-expanded', 'false');
        trigger.innerHTML = `
            <span class="aselect-trigger-text placeholder">${placeholder}</span>
            <div class="aselect-trigger-icons">
                <button type="button" class="aselect-clear" title="Limpiar">
                    <i class="bi bi-x"></i>
                </button>
                <i class="bi bi-chevron-down aselect-chevron"></i>
            </div>`;
        wrapper.appendChild(trigger);

        const dropdown = document.createElement('div');
        dropdown.className = 'aselect-dropdown';
        dropdown.innerHTML = `
            <div class="aselect-search-wrap">
                <i class="bi bi-search aselect-search-icon"></i>
                <input type="text" class="aselect-search" placeholder="${searchPlaceholder}" autocomplete="off" />
            </div>
            <div class="aselect-options"></div>`;
        wrapper.appendChild(dropdown);

        // ── Referencias ────────────────────
        const triggerText = trigger.querySelector('.aselect-trigger-text');
        const clearBtn = trigger.querySelector('.aselect-clear');
        const searchInput = dropdown.querySelector('.aselect-search');
        const optionsList = dropdown.querySelector('.aselect-options');

        let loaded = false;
        let isOpen = false;
        let allItems = [];

        // ── Abrir / cerrar ─────────────────
        function open()
        {
            if (isOpen) return;
            isOpen = true;

            // cerrar otros dropdowns abiertos
            document.querySelectorAll('.aselect-dropdown.open').forEach(d =>
            {
                if (d !== dropdown) d.closest('.aselect-wrapper')
                    ?.__asyncSelectClose?.();
            });

            trigger.classList.add('open');
            trigger.setAttribute('aria-expanded', 'true');
            dropdown.classList.add('open');
            searchInput.value = '';
            filterOptions('');

            if (!loaded) loadOptions();
            else setTimeout(() => searchInput.focus(), 50);
        }

        function close()
        {
            if (!isOpen) return;
            isOpen = false;
            trigger.classList.remove('open');
            trigger.setAttribute('aria-expanded', 'false');
            dropdown.classList.remove('open');
        }

        wrapper.__asyncSelectClose = close;

        // ── Cargar opciones desde URL ──────
        async function loadOptions()
        {
            showState('loading');

            try
            {
                const query = new URLSearchParams({ ...params }).toString();
                const sep = url.includes('?') ? '&' : '?';
                const fullUrl = query ? `${url}${sep}${query}` : url;

                const res = await fetch(fullUrl, {
                    headers: { 'X-Requested-With': 'XMLHttpRequest' }
                });

                if (!res.ok) throw new Error(`HTTP ${res.status}`);

                const data = await res.json();
                allItems = Array.isArray(data) ? data : (data.items ?? data.data ?? []);
                loaded = true;

                renderOptions(allItems);
                setTimeout(() => searchInput.focus(), 50);

            } catch (err)
            {
                console.error('AsyncSelect fetch error:', err);
                showState('error');
            }
        }

        // ── Renderizar opciones ────────────
        function renderOptions(items)
        {
            if (items.length === 0) { showState('empty'); return; }

            optionsList.innerHTML = '';
            const currentVal = nativeSelect.value;

            items.forEach(item =>
            {
                const val = String(item[valueField] ?? '');
                const label = item[labelField] ?? '';

                const el = document.createElement('div');
                el.className = 'aselect-option' + (val === currentVal ? ' selected' : '');
                el.dataset.value = val;
                el.dataset.label = label;
                el.textContent = label;

                el.addEventListener('click', () => selectOption(val, label));
                optionsList.appendChild(el);
            });
        }

        // ── Filtrar por búsqueda ───────────
        function filterOptions(query)
        {
            if (!loaded) return;
            const q = query.toLowerCase().trim();

            let visibleCount = 0;
            optionsList.querySelectorAll('.aselect-option').forEach(el =>
            {
                const match = el.dataset.label.toLowerCase().includes(q);
                el.classList.toggle('hidden', !match);
                if (match) visibleCount++;
            });

            if (visibleCount === 0 && q.length > 0) showState('no-results');
            else
            {
                const state = optionsList.querySelector('.aselect-state');
                if (state) state.remove();
            }
        }

        // ── Seleccionar opción ─────────────
        function selectOption(val, label)
        {
            // actualizar nativeSelect (mantiene el model binding)
            let opt = nativeSelect.querySelector(`option[value="${val}"]`);
            if (!opt)
            {
                opt = document.createElement('option');
                opt.value = val;
                nativeSelect.appendChild(opt);
            }
            opt.textContent = label;
            nativeSelect.value = val;

            // disparar change para cualquier listener externo
            nativeSelect.dispatchEvent(new Event('change', { bubbles: true }));

            // actualizar trigger
            triggerText.textContent = label;
            triggerText.classList.remove('placeholder');
            wrapper.classList.add('has-value');

            // marcar selected visualmente
            optionsList.querySelectorAll('.aselect-option').forEach(el =>
            {
                el.classList.toggle('selected', el.dataset.value === val);
            });

            close();
        }

        // ── Limpiar selección ──────────────
        function clearSelection()
        {
            nativeSelect.value = '';
            nativeSelect.dispatchEvent(new Event('change', { bubbles: true }));

            triggerText.textContent = placeholder;
            triggerText.classList.add('placeholder');
            wrapper.classList.remove('has-value');

            optionsList.querySelectorAll('.aselect-option')
                .forEach(el => el.classList.remove('selected'));
        }

        // ── Estados (loading/empty/error) ──
        function showState(type)
        {
            const existing = optionsList.querySelector('.aselect-state');
            if (existing) existing.remove();

            const stateMap = {
                loading: `<div class="aselect-spinner"></div><span>Cargando...</span>`,
                empty: `<i class="bi bi-inbox"></i><span>Sin opciones disponibles</span>`,
                'no-results': `<i class="bi bi-search"></i><span>Sin resultados</span>`,
                error: `<i class="bi bi-wifi-off"></i><span>Error al cargar opciones</span>`
            };

            const el = document.createElement('div');
            el.className = 'aselect-state';
            el.innerHTML = stateMap[type] || '';
            optionsList.appendChild(el);
        }

        // ── Restaurar valor inicial ────────
        // Si el select nativo ya tiene un valor seleccionado (ej: edición)
        const initialVal = nativeSelect.value;
        if (initialVal && initialVal !== '0' && initialVal !== '')
        {
            const initialText = nativeSelect.options[nativeSelect.selectedIndex]?.text ?? initialVal;
            triggerText.textContent = initialText;
            triggerText.classList.remove('placeholder');
            wrapper.classList.add('has-value');
        }

        // ── Eventos ────────────────────────
        trigger.addEventListener('click', e =>
        {
            if (e.target.closest('.aselect-clear')) return;
            isOpen ? close() : open();
        });

        trigger.addEventListener('keydown', e =>
        {
            if (e.key === 'Enter' || e.key === ' ') { e.preventDefault(); isOpen ? close() : open(); }
            if (e.key === 'Escape') close();
        });

        clearBtn.addEventListener('click', e =>
        {
            e.stopPropagation();
            clearSelection();
        });

        searchInput.addEventListener('input', e => filterOptions(e.target.value));

        searchInput.addEventListener('keydown', e =>
        {
            if (e.key === 'Escape') close();
        });

        // cerrar al hacer clic fuera
        document.addEventListener('click', e =>
        {
            if (!wrapper.contains(e.target)) close();
        });

        // ── API pública ────────────────────
        // Permite recargar con parámetros nuevos desde JS:
        // AsyncSelect.reload(selectEl, { areaId: 5 })
        nativeSelect.__asyncSelect = {
            reload(newParams = {})
            {
                loaded = false;
                allItems = [];
                Object.assign(params, newParams);
                if (isOpen) loadOptions();
            },
            setValue(val, label) { selectOption(val, label); },
            clear() { clearSelection(); }
        };
    }

    // ── API pública ──────────────────────────
    function reload(nativeSelect, newParams = {})
    {
        nativeSelect.__asyncSelect?.reload(newParams);
    }

    function setValue(nativeSelect, val, label)
    {
        nativeSelect.__asyncSelect?.setValue(val, label);
    }

    function clear(nativeSelect)
    {
        nativeSelect.__asyncSelect?.clear();
    }

    // Auto-init al cargar el DOM
    document.addEventListener('DOMContentLoaded', initAll);

    return { init, initAll, reload, setValue, clear };

})();