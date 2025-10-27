import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Home from "./components/Home";
import Footer from "./components/Footer";
import KeywordPlayground from "./components/KeywordPlayground";

function App() {
  return (
    <>
      <BrowserRouter>
        <Layout>
          <Routes>
            {/* home / landing page */}
            <Route path="/" element={<Home />} />

            {/* keyword tester page */}
            <Route path="/keywords" element={<KeywordPlayground />} />
          </Routes>
        </Layout>
      </BrowserRouter>

      <Footer />
    </>
  );
}

export default App;
