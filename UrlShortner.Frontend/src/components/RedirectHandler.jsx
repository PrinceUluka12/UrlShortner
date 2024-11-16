import React, { useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';

const RedirectHandler = () => {
    const { shortUrl } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const redirectToLongUrl = async () => {
          try {
            // Make a request to the backend to get the long URL
            const response = await axios.get(`https://localhost:7038/api/UrlShortener/${shortUrl}`);
            
            setTimeout(() => {
              // Redirect to the original long URL
            if (response.status === 200) {              
              window.open(response.data.longUrl, '_blank');
              window.close();
            } else {
              navigate('/not-found'); // Navigate to a "Not Found" page if the URL isn't found
            }
            }, 3000)
            
          } catch (error) {
            console.error('Error fetching the original URL:', error);
            navigate('/error'); // Navigate to an error page if there is an issue with the request
          }
        };
    
        redirectToLongUrl();
      }, [shortUrl, navigate]);
    
      return (
        <div className="container text-center mt-5">
          <div className="spinner-border text-primary" role="status">
            <span className="visually-hidden">Redirecting...</span>
          </div>
          <p className="mt-3">Redirecting...</p>
        </div>
      );
    };
    
    export default RedirectHandler;