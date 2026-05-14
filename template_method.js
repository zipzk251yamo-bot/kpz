// 1. ШАБЛОННИЙ МЕТОД (Template Method)
// Додає хуки життєвого циклу для елементів

abstract class HTMLElementBase {
    public children: any[] = [];
    public styles: Record<string, string> = {};

    constructor(public name: string) {}

    // Шаблонний метод рендерингу
    public render(): string {
        this.onCreated(); // Хук створення
        this.onStylesApplied(); // Хук застосування стилів
        
        let content = `<${this.name} style="${this.formatStyles()}">`;
        content += this.renderChildren();
        content += `</${this.name}>`;
        
        this.onRendered(); // Хук завершення рендеру
        return content;
    }

    // Методи-хуки, які можна перевизначити в підкласах
    protected onCreated(): void { 
        console.log(`[Lifecycle] Елемент ${this.name} створено`); 
    }
    
    protected onStylesApplied(): void { 
        console.log(`[Lifecycle] Стилі застосовано до ${this.name}`); 
    }
    
    protected onRendered(): void { 
        console.log(`[Lifecycle] Елемент ${this.name} успішно відрендерено`); 
    }

    private formatStyles(): string {
        return Object.entries(this.styles).map(([k, v]) => `${k}:${v}`).join(';');
    }

    protected abstract renderChildren(): string;
}

class CustomElement extends HTMLElementBase {
    protected renderChildren(): string {
        return this.children.map(child => child.render?.() || "").join('');
    }
}