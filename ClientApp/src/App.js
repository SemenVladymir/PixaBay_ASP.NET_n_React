import React, { Component } from 'react';
import './App.css';

class App extends Component {

  constructor(props) {
    super(props);
    this.state = {
      images: []
    }
  }

  API_URL = "http://localhost:5267/";

  async addClick() {
    const data = new FormData();
    data.append("Name", document.getElementById("search").value);
    data.append("UrlPhoto", "non");
    data.append("Size", document.getElementById("Number").value);


    fetch(this.API_URL + "api/Image/GetImages", {
      method: "POST",
      body: data
    }).then(res => res.json()).then((result) => {
      alert(result);
      this.setState({ images: result });
    })
  }

  render() {
    const { images } = this.state;
    
  
    return (
      <div className="App">
        <header>
          <div className='head'>
          <h2>Searching image on the pixabay</h2>
          <label> Search name images </label>
          <input id="search" />&nbsp;
          
          <label> Number of images </label>
          <input id="Number" />&nbsp;
          
            <button onClick={() => this.addClick()}>Search</button>
            </div>
        </header>
        <body>
            <div className='container'>
              {images.map(image =>
                <div className='item-content'>
                  <img src={image.UrlPhoto} alt="pixabay"></img>
                </div>
              )}
            </div>
        </body>
      </div>
    );
  }
}
export default App;
