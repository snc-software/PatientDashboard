import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css';
import Layout from './layout/Layout';
import Home from './pages/Home';

function App() {
  return (
      <BrowserRouter>
        <Layout children={
          <Routes>
            <Route path="/" element={<Home />} />
          </Routes>
        }/>
      </BrowserRouter>
  );
}

export default App;
