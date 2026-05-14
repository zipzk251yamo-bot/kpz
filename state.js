// 4. СТЕЙТ (State)
// Керування поведінкою елемента залежно від його стану (видимий/прихований)

interface ElementState {
    getDisplay(): string;
}

class VisibleState implements ElementState {
    getDisplay(): string { return "block"; }
}

class HiddenState implements ElementState {
    getDisplay(): string { return "none"; }
}

class ElementContext {
    private state: ElementState = new VisibleState();

    public setState(state: ElementState): void {
        this.state = state;
    }

    public applyToElement(element: any): void {
        element.styles['display'] = this.state.getDisplay();
    }
}