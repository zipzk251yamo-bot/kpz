// 2. ІТЕРАТОР (Iterator)
// Дозволяє перебирати дерево HTML в глибину

class HTMLTreeIterator implements IterableIterator<any> {
    private stack: any[];

    constructor(root: any) {
        this.stack = [root];
    }

    public next(): IteratorResult<any> {
        if (this.stack.length === 0) {
            return { done: true, value: null };
        }

        const node = this.stack.pop()!;
        
        // Додаємо дітей у стек (у зворотному порядку для правильного обходу)
        if (node.children) {
            for (let i = node.children.length - 1; i >= 0; i--) {
                this.stack.push(node.children[i]);
            }
        }

        return { done: false, value: node };
    }

    [Symbol.iterator](): IterableIterator<any> {
        return this;
    }
}