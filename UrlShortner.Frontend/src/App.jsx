import React, { useState } from 'react';
import axios from 'axios';
import './App.css';

function App() {
  const [userName, setUserName] = useState('');
  const [longUrl, setLongUrl] = useState('');
  const [length, setLength] = useState(8);
  const [shortUrl, setShortUrl] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const response = await axios.post('https://localhost:7038/api/UrlShortener/shorten', {
        userName,
        longUrl,
        length
      });

      setShortUrl(response.data.shortUrl);
    } catch (error) {
      console.error('Error creating short URL:', error);
      alert('An error occurred while generating the short URL.');
    }
  };

  return (
    <div className="App">
      <h1 className="app-title">🌐 URL Shortener</h1>
      <form className="url-form" onSubmit={handleSubmit}>
        <div className="form-group">
          <label>User Name: </label>
          <input
            type="text"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            placeholder="Enter your name"
            required
          />
        </div>
        <div className="form-group">
          <label>Long URL: </label>
          <input
            type="url"
            value={longUrl}
            onChange={(e) => setLongUrl(e.target.value)}
            placeholder="Enter the long URL"
            required
          />
        </div>
        <div className="form-group">
          <label>Short URL Length: </label>
          <input
            type="number"
            value={length}
            onChange={(e) => setLength(e.target.value)}
            min="5"
            max="50"
            required
          />
        </div>
        <button type="submit" className="submit-button">Generate Short URL</button>
      </form>

      {shortUrl && (
        <div className="result">
          <h2>🎉 Generated Short URL:</h2>
          <a href={`https://localhost:5001/redirect/${shortUrl}`} target="_blank" rel="noopener noreferrer">
            {`https://localhost:5001/redirect/${shortUrl}`}
          </a>
        </div>
      )}
    </div>
  );
}

export default App;
