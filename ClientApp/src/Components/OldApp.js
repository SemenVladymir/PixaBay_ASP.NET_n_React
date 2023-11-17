import React, { Component } from 'react';
import './OldApp.css';

class OldApp extends Component {

  constructor(props) {
    super(props);
    this.state = {
      images: []
    }
  }

  API_URL = "http://vladimyrsemen-001-site1.gtempurl.com/";

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

  async SaveImage(event, image){
    
    const data = new FormData();
    data.append("Name", image.Name);
    data.append("UrlPhoto", image.UrlPhoto);
    data.append("Size", 0);
    fetch("http://localhost:5267/api/Image/SaveImage", {
      method: "POST",
      
      body: data
    }).then(res => res.json()).then((result) => {
      alert(result);
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
          <input id="search" placeholder="search name"/>&nbsp;
          
          <label> Number of images </label>
          <input id="Number"  />&nbsp;
          
            <button onClick={() => this.addClick()}>Search</button>
            </div>
        </header>
        <div className='body'>
            <div className='container'>
            {images.map((image) => 
              <div className='item-content' key={image.UrlPhoto}>
                <img src={image.UrlPhoto} alt="img.pixabay"/>
                  <button onClick={(e)=>this.SaveImage(e.preventDefault(), image)}>Save</button>
                </div>
              )}
            </div>
        </div>
      </div>
    );
  }
}
export default OldApp;