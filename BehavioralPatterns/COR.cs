using System;

public class Program {
    static void Main(string[] args) {
        // client code
        SquareHole sh = new SquareHole();
        CircleHole ch = new CircleHole();
        TriangleHole th = new TriangleHole();

        // smallest to biggest
        th.set_handler(ch).set_handler(sh);
        string[] shapes = new string[] {"cube", "tetrahedron", "sphere", "diamond"};

        foreach (string shape in shapes) {
            string r = th.handle(shape);

            if (r != null) {
                System.Console.WriteLine(r);
            } else {
                System.Console.WriteLine(shape + " does not fit in any hole");
            }
        }
    }
}

interface Handler {
    Handler set_handler(Handler h);
    string handle(string request);
}

class BaseHandler : Handler {
    Handler next;

    public Handler set_handler(Handler h) {
        this.next = h;
        return h;
    }

    public virtual string handle(string request) {
        if (this.next != null) {
            return this.next.handle(request);
        }

        return null;
    }
}

// concrete handlers
class SquareHole : BaseHandler{
    public override string handle(string request) {
        if (request == "cube") {
            return request + " fits in square hole.";
        } else {
            return base.handle(request);
        }
    }
}

class CircleHole : BaseHandler{
    public override string handle(string request) {
        if (request == "sphere" || request == "cylinder") {
            return request + " fits in circle hole.";
        } else {
            return base.handle(request);
        }
    }
}

class TriangleHole : BaseHandler{
    public override string handle(string request) {
        if (request == "tetrahedron") {
            return request + " fits in triangle hole.";
        } else {
            return base.handle(request);
        }
    }
}