import CssBaseline from '@mui/material/CssBaseline';
import React from 'react';
import ReactDOM from 'react-dom/client';
import { ThemeProvider } from '@mui/material/styles';
import App from './App';
import lightTheme from './themes/lightTheme';
import './index.css'
import { HubContextProvider } from './contexts/HubContext';
import axios from 'axios';

const root = ReactDOM.createRoot(
    document.getElementById('root') as HTMLElement
);
root.render(
    <React.StrictMode>
        <ThemeProvider theme={lightTheme} >
            <CssBaseline />

            <HubContextProvider>
                <App />
            </HubContextProvider>
            
        </ThemeProvider>
    </React.StrictMode>
);
async function fetchDanilku() {
        const superData = await axios.get('http://localhost:5000/api/error')
        console.log('fetched data ---', superData)
    }
fetchDanilku().then()
console.log([
    ["route", window.location.pathname],
    ["location ---", window.location],
])