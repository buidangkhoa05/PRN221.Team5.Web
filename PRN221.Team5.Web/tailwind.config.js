const { fontFamily } = require('tailwindcss/defaultTheme')
const colors = require('tailwindcss/colors')
module.exports = {
    purge: {
        enabled: true,
        content: ["./Pages/**/*.cshtml", "./Views/**/*.cshtml"],
    },
    darkMode: false,
    theme: {
    },
    plugins: [require('@tailwindcss/forms'), require('@tailwindcss/typography')],
    variants: {
        extend: {},
    },
};