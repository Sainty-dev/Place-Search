# PlaceExplorer Xamarin.Forms App
![PlaceExplorer App Screenshot](https://firebasestorage.googleapis.com/v0/b/apartment-management-sys-5cdc7.appspot.com/o/demo.png?alt=media&token=0fed0ec6-253c-430e-957e-c8df84c51a07)
## Overview

**PlaceSearch** is a Xamarin.Forms app that allows users to search for places based on a single input criterion and view detailed information about each place. The app uses RestSharp for API interactions and displays results using Xamarin.Forms.

## Features

- **Search Places:** Search for places based on an input criterion.
- **Display Results:** Show a list of places with `mainText` and `secondaryText`.
- **View Details:** Request and display additional details for a selected place.

## API Endpoints

- **Search Places**
  - **Endpoint:** `/api/v1/locations/places`
  - **Method:** GET
  - **Description:** Retrieves a list of places based on the search criterion.

- **Get Place Details**
  - **Endpoint:** `/api/v1/locations/places/{id}`
  - **Method:** GET
  - **Description:** Retrieves detailed information about a specific place.

## Prerequisites

- Xamarin.Forms
- RestSharp
-  Xamarin.Forms development environment

## Setup

1. **Clone the Repository**

   ```bash
   git clone <repository-url>
   cd Place-Search
