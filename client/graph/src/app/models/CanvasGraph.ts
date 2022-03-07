

export class CanvasGraph {


    canvas: HTMLCanvasElement;
    minX: number;
    minY: number;
    maxX: number;
    maxY: number;
    unitsPerTick: number;

    axisColor: string;
    font: string;
    tickSize: number;

    context: CanvasRenderingContext2D;
    rangeX: number;
    rangeY: number;
    unitX: number;
    unitY: number;
    centerY: number;
    centerX: number;
    iteration: number;
    scaleX: number;
    scaleY: number;

    //הגדרת שאר המשתנים


    constructor(con: any) {
        this.canvas = document.getElementById(con.canvasId) as HTMLCanvasElement;
        this.minX = con.minX;
        this.minY = con.minY;
        this.maxX = con.maxX;
        this.maxY = con.maxY;
        this.unitsPerTick = con.unitsPerTick;

        // constants  
        this.axisColor = "#aaa";
        this.font = "8pt Calibri";
        this.tickSize = 20;

        // relationships  
        const res = this.canvas.getContext('2d');

        if (!res || !(res instanceof CanvasRenderingContext2D)) {
            throw new Error('Failed to get 2D context');
        }
        this.context = res;
        this.rangeX = this.maxX - this.minX;
        this.rangeY = this.maxY - this.minY;
        this.unitX = this.canvas.width / this.rangeX;
        this.unitY = this.canvas.height / this.rangeY;
        this.centerY = Math.round(Math.abs(this.minY / this.rangeY) * this.canvas.height);
        this.centerX = Math.round(Math.abs(this.minX / this.rangeX) * this.canvas.width);
        this.iteration = (this.maxX - this.minX) / 1000;
        this.scaleX = this.canvas.width / this.rangeX;
        this.scaleY = this.canvas.height / this.rangeY;

        this.drawXAxis();
        this.drawYAxis();
    }


    drawXAxis() {
        var context = this.context;
        context.save();
        context.beginPath();
        context.moveTo(0, this.centerY);
        context.lineTo(this.canvas.width, this.centerY);
        context.strokeStyle = this.axisColor;
        context.lineWidth = 2;
        context.stroke();

        // draw tick marks  
        var xPosIncrement = this.unitsPerTick * this.unitX;
        var xPos, unit;
        context.font = this.font;
        context.textAlign = "center";
        context.textBaseline = "top";

        // draw left tick marks  
        xPos = this.centerX - xPosIncrement;
        unit = -1 * this.unitsPerTick;
        while (xPos > 0) {
            context.moveTo(xPos, this.centerY - this.tickSize / 2);
            context.lineTo(xPos, this.centerY + this.tickSize / 2);
            context.stroke();
            context.fillText(unit.toString(), xPos, this.centerY + this.tickSize / 2 + 3);
            unit -= this.unitsPerTick;
            xPos = Math.round(xPos - xPosIncrement);
        }

        // draw right tick marks  
        xPos = this.centerX + xPosIncrement;
        unit = this.unitsPerTick;
        while (xPos < this.canvas.width) {
            context.moveTo(xPos, this.centerY - this.tickSize / 2);
            context.lineTo(xPos, this.centerY + this.tickSize / 2);
            context.stroke();
            context.fillText(unit.toString(), xPos, this.centerY + this.tickSize / 2 + 3);
            unit += this.unitsPerTick;
            xPos = Math.round(xPos + xPosIncrement);
        }
        context.restore();
    };


    drawYAxis() {
        const context = this.context;
        context.save();
        context.beginPath();
        context.moveTo(this.centerX, 0);
        context.lineTo(this.centerX, this.canvas.height);
        context.strokeStyle = this.axisColor;
        context.lineWidth = 2;
        context.stroke();

        // draw tick marks   
        const yPosIncrement = this.unitsPerTick * this.unitY;
        let yPos: number, unit: number;
        context.font = this.font;
        context.textAlign = "right";
        context.textBaseline = "middle";

        // draw top tick marks  
        yPos = this.centerY - yPosIncrement;
        unit = this.unitsPerTick;
        while (yPos > 0) {
            context.moveTo(this.centerX - this.tickSize / 2, yPos);
            context.lineTo(this.centerX + this.tickSize / 2, yPos);
            context.stroke();
            context.fillText(unit.toString(), this.centerX - this.tickSize / 2 - 3, yPos);
            unit += this.unitsPerTick;
            yPos = Math.round(yPos - yPosIncrement);
        }

        // draw bottom tick marks  
        yPos = this.centerY + yPosIncrement;
        unit = -1 * this.unitsPerTick;
        while (yPos < this.canvas.height) {
            context.moveTo(this.centerX - this.tickSize / 2, yPos);
            context.lineTo(this.centerX + this.tickSize / 2, yPos);
            context.stroke();
            context.fillText(unit.toString(), this.centerX - this.tickSize / 2 - 3, yPos);
            unit -= this.unitsPerTick;
            yPos = Math.round(yPos + yPosIncrement);
        }
        context.restore();
    };

    drawEquation(equation: Function, color: string, thickness: number) {
        var context = this.context;
        context.save();
        context.save();
        this.transformContext();

        context.beginPath();
        context.moveTo(this.minX, equation(this.minX));

        for (var x = this.minX + this.iteration; x <= this.maxX; x += this.iteration) {
            context.lineTo(x, equation(x));
        }

        context.restore();
        context.lineJoin = "round";
        context.lineWidth = thickness;
        context.strokeStyle = color;
        context.stroke();
        context.restore();
    };

    transformContext() {
        var context = this.context;

        // move context to center of canvas  
        this.context.translate(this.centerX, this.centerY);

        context.scale(this.scaleX, -this.scaleY);
    };

}