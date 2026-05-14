// 3. КОМАНДА (Command)
// Операції над елементами з можливістю скасування (Undo)

interface Command {
    execute(): void;
    undo(): void;
}

class ChangeStyleCommand implements Command {
    private oldStyle: string;

    constructor(
        private element: any, 
        private property: string, 
        private value: string
    ) {
        this.oldStyle = element.styles[property] || "";
    }

    execute(): void {
        this.element.styles[this.property] = this.value;
        console.log(`Команда: Змінено ${this.property} на ${this.value}`);
    }

    undo(): void {
        this.element.styles[this.property] = this.oldStyle;
        console.log(`Відкат: Повернуто ${this.property} до значення "${this.oldStyle}"`);
    }
}