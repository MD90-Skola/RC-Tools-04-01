using Microsoft.Web.WebView2.WinForms;
using System.Threading.Tasks;

namespace Modern.Forms
{
    public static class FunctionCsgoRoll
    {
        public static async Task ApplyFilters(WebView2 webView)
        {
            string script = @"
                (async () => {
                    const wait = ms => new Promise(res => setTimeout(res, ms));

                    // 1. Stäng eventuell öppen chatt
                    const closeChat = () => {
                        const btn = document.querySelector('button.mat-focus-indicator.close.clip-bl.mat-icon-button.mat-button-base');
                        if (btn) btn.click();
                    };

                    // 2. Prisfilter
                    const setPrice = () => {
                        const max = document.querySelector('input[data-test=""max-price""]');
                        const min = document.querySelector('input[data-test=""min-price""]');
                        if (max) { max.value = '1500'; max.dispatchEvent(new Event('input', { bubbles: true })); }
                        if (min) { min.value = '10'; min.dispatchEvent(new Event('input', { bubbles: true })); }
                    };

                    // 3. Tryck på max-knapp
                    const clickMax = () => {
                        const btn = document.querySelector('button.mat-focus-indicator.fs-12.text-white.max-btn');
                        if (btn) btn.click();
                    };

                    // 4. Välj 'Best deals'
                    const selectBestDeals = async () => {
                        const dropdown = document.querySelector('mat-select[formcontrolname=""orderBy""]');
                        if (!dropdown) return;
                        dropdown.click();
                        await wait(250);
                        const best = document.querySelector('mat-option#mat-option-3');
                        if (best && !best.classList.contains('mat-selected')) best.click();
                        document.body.click();
                    };

                    // 5. Dölj oönskade element och sätt zoom + volym
                    const hideElements = () => {
                        const css = `
                            nav.main-nav,
                            input[data-test=""search-input""],
                            input[data-test=""min-price""],
                            input[data-test=""max-price""],
                            mat-select[formcontrolname=""orderBy""],
                            [formcontrolname=""orderBy""],
                            button[data-test=""category-list-item""],
                            footer,
                            header,
                            .chat-container,
                            .banner,
                            .ads,
                            #mat-input-0,
                            mat-form-field.order-by,
                            mat-form-field.ng-star-inserted,
                            button.list-btn,
                            button.chat-toggle,
                            button.live-chat-open,
                            .auth-footer-container {
                                display: none !important;
                            }

                            body {
                                zoom: 0.8 !important;
                                overflow: auto !important;
                            }
                        `;
                        const style = document.createElement('style');
                        style.textContent = css;
                        document.head.appendChild(style);

                        const setVolume = () => {
                            document.querySelectorAll('audio, video').forEach(el => el.volume = 0.8);
                        };
                        setVolume();
                        setInterval(setVolume, 3000);
                    };

                    // Ny funktion för att styla procentvärdet
                    const stylePercentage = () => {
                        document.querySelectorAll('*').forEach(el => {
                            if (el.childNodes.length === 1 && el.childNodes[0].nodeType === Node.TEXT_NODE) {
                                let match = el.textContent.match(/([+-]\\d+(\\.\\d+)?)%/);
                                if (match) {
                                    const number = match[1];
                                    el.innerHTML = el.textContent.replace(
                                        number,
                                        `<span class='custom-percentage'>${number}</span>`
                                    );
                                }
                            }
                        });

                        const style = document.createElement('style');
                        style.innerHTML = `
                            .custom-percentage {
                                font-size: 76px !important; 
                                color: #00ff00 !important;
                                font-weight: bold !important;
                            }
                        `;
                        document.head.appendChild(style);
                    };

                    // ✅ Kör alla steg
                    closeChat();
                    await wait(200);
                    setPrice();
                    clickMax();
                    await wait(200);
                    await selectBestDeals();
                    hideElements();
                    stylePercentage();
                    window.scrollBy(0, 90);

                })();
            ";

            await webView.ExecuteScriptAsync(script);
        }

        public static async Task ScrollDown10Px(WebView2 webView)
        {
            string scrollScript = "window.scrollBy(0, -100);";
            await webView.ExecuteScriptAsync(scrollScript);
        }
    }
}
