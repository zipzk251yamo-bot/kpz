// 5. ВІДВІДУВАЧ (Visitor)
// Операції над структурою без зміни самих класів елементів

interface Visitor {
    visit(element: any): void;
}

class AnalyticsVisitor implements Visitor {
    public totalElements: number = 0;
    public tags: string[] = [];

    visit(element: any): void {
        this.totalElements++;
        this.tags.push(element.name);
        console.log(`Аналітика: знайдено тег <${element.name}>`);
    }
}