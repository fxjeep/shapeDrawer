import React, { useState, useEffect } from 'react';
import ShapeInstruction from '../api/ShapeInstruction';

type Props = { data: ShapeInstruction };

export default function SVGShape(props:Props ){

    const[path, setPath] = useState("");

    useEffect(()=>{
        if (props.data.svgType == "Path")
        {
            let strPath = "M0 0 ";
            props.data.points.forEach(item=>{
                strPath += "L"+item.x+" "+item.y+" ";
            })
            setPath(strPath);
        }
    }, [props.data.points])
    

    return (
        <div className="card">
            <header className="card-header">
                <p className="card-header-title">{props.data.name} - </p>
            </header>
            <div className="card-content">
                <div className="content">
                    <svg viewBox="0 0 100 100" xmlns="http://www.w3.org/2000/svg">
                        {
                            props.data.svgType == "Circle"? (
                                <circle cx={props.data.radius+'px'} cy={props.data.radius+'px'} r={props.data.radius+'px'} stroke="black" stroke-width="1px" fill="none"/> 
                            ):""
                        }
                        {
                            props.data.svgType == "Oval"? (
                                <ellipse cx={props.data.radius1+'px'} cy={props.data.radius1+'px'} rx={props.data.radius1+'px'} ry={props.data.radius2+'px'} stroke="black" stroke-width="1px" fill="none"/> 
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