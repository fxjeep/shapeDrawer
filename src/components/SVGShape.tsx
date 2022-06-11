import React, { useState, useEffect } from 'react';
import ShapeInstruction from '../api/ShapeInstruction';

type Props = { data: ShapeInstruction };

export default function SVGShape(props:Props ){

    const[path, setPath] = useState("");

    useEffect(()=>{
        if (props.data.svgType == "Path")
        {
            let strPath = "";
            for(let i=0; i<props.data.points.length; i++)
            {
                let x= props.data.points[i].x+200;
                let y = props.data.points[i].y+200;
                if (i==0){
                    strPath += "M "+x+" "+ y + " "
                }else{
                    strPath += "L "+x+" "+y+" ";
                }
            }
            setPath(strPath+" Z");
        }
    }, [props.data.points])
    

    return (
        <div className="card">
            <header className="card-header">
                <p className="card-header-title">{props.data.name} - </p>
            </header>
            <div className="card-content">
                <div className="content">
                    <svg viewBox="0 0 100% 100%" xmlns="http://www.w3.org/2000/svg" height="800" width="800">
                        {
                            props.data.svgType == "Circle"? (
                                <circle cx="400" cy="400" r={props.data.radius+'px'} stroke="black" stroke-width="1px" fill="none"/> 
                            ):""
                        }
                        {
                            props.data.svgType == "Oval"? (
                                <ellipse cx="400" cy="400" rx={props.data.radius1+'px'} ry={props.data.radius2+'px'} stroke="black" stroke-width="1px" fill="none"/> 
                            ):""
                        }
                        {
                            props.data.svgType == "Path"? (
                                <path d={path} fill="none" stroke="black"/>
                            ):""
                        }
                        
                    </svg>
                </div>
            </div>
        </div>
    );
}