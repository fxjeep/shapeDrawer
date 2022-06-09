import React, { useState, MouseEvent, ChangeEvent } from 'react';
import ShapeInstruction from '../api/ShapeInstruction';
import SVGShape from './SVGShape';

const drawShapeUrl = "http://localhost:5177/api/Shape/Drawing";

function ShapeDrawer() {

  const [instruction, setInstruction] = useState("");
  const [shapeData, setShapeData] = useState<ShapeInstruction>(new ShapeInstruction());

  const updateInstruction = (e: ChangeEvent<HTMLInputElement>)=>{
        setInstruction(e.target.value);
  }

  const draw = (event: MouseEvent)=>{
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ text: instruction })
    };
    fetch(drawShapeUrl, requestOptions)
        .then(response => response.json() as Promise<ShapeInstruction>)
        .then(data => {
            setShapeData(data);
        });
  }

  return (
    <div className="container">
        <div className="panel is-info">
            <p className="panel-heading">
                Shape Drawer
            </p>
            <div className="panel-block">
                <p className="control has-icons-left">
                Type your instruction:
                <input type="text" className="input is-info" value={instruction} onChange={updateInstruction}/>
                <span className="icon is-left">
                    <i className="fas fa-search" aria-hidden="true"></i>
                </span>
                <button className="button is-primary" onClick={draw}>Draw</button>
                </p>
            </div>
            {
                shapeData.name == "None"?(
                    <div className="panel-block">
                        <div className="notification is-danger">
                            <p>Your instruction is invalid, please check</p>
                        </div>
                    </div>
                ):
                (
                    <div>
                        <SVGShape data={shapeData}></SVGShape>
                    </div>
                )
            }
            
        </div>
    </div>
  );
}

export default ShapeDrawer;
