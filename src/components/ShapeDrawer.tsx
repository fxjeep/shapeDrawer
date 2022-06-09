import React, { useState, MouseEvent, ChangeEvent } from 'react';

const drawShapeUrl = "http://localhost:5177";

function ShapeDrawer() {

  const [instruction, setInstruction] = useState("");

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
        .then(response => response.json())
        .then(data => {
            alert(data);
        });
  }

  return (
    <div className="ShapeDrawer">
        <div>
            Type your instruction:
        </div>
        <div>
            <input type="text" value={instruction} onChange={updateInstruction}/>
            <button onClick={draw}>Draw</button>
        </div>
        <div>
            Shapes:
        </div>
        <div>

        </div>
    </div>
  );
}

export default ShapeDrawer;
