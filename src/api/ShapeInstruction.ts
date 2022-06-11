class Point {
    x!: number;
    y!: number;
}
export default class ShapeInstruction {
    points! : Array<Point>;
    invalidInstruction! : boolean;
    name! : string;
    radius!: number;
    radius1!: number;
    radius2!: number;
    svgType!: string;
}
