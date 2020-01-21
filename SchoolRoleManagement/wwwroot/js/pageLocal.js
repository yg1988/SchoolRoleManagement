function GenerateGraph(graphData) {
    var g = new dagre.graphlib.Graph();
    console.log(graphData);
    // Set an object for the graph label
    g.setGraph({});

    // Default to assigning a new object as a label for each new edge.
    g.setDefaultEdgeLabel(function () { return {}; });

    // Add nodes to the graph. The first argument is the node id. The second is
    // metadata about the node. In this case we're going to add labels to each of
    // our nodes.
    _.map(graphData.roles, function (role) {
        if (role.requireTenure) {
            g.setNode(role.roleName, {
                label: role.roleName,
                style: "fill: #7f7"
            });
        }
        else {
            g.setNode(role.roleName, { label: role.roleName });
        }

    });
    //g.setNode("kspacey", { label: "Kevin Spacey", width: 144, height: 100 });
    //g.setNode("swilliams", { label: "Saul Williams", width: 160, height: 100 });
    //g.setNode("bpitt", { label: "Brad Pitt", width: 108, height: 100 });
    //g.setNode("hford", { label: "Harrison Ford", width: 168, height: 100 });
    //g.setNode("lwilson", { label: "Luke Wilson", width: 144, height: 100 });
    //g.setNode("kbacon", { label: "Kevin Bacon", width: 121, height: 100 });

    _.map(graphData.transitions, function (transition) { g.setEdge(transition.from.roleName, transition.to.roleName) });
    // Add edges to the graph.
    //g.setEdge("kspacey", "swilliams");
    //g.setEdge("swilliams", "kbacon");
    //g.setEdge("bpitt", "kbacon");
    //g.setEdge("hford", "lwilson");
    //g.setEdge("lwilson", "kbacon");
    //dagre.layout(g);

    var render = new dagreD3.render();



    // Set up an SVG group so that we can translate the final graph.
    var svg = d3.select("svg"),
        inner = svg.append("g");
    var zoom = d3.zoom().on("zoom", function () {
        inner.attr("transform", d3.event.transform);
    });

    svg.call(zoom);
    render(inner, g);

    // Center the graph
    var initialScale = 0.75;
    svg.call(zoom.transform, d3.zoomIdentity.translate((svg.attr("width") - g.graph().width * initialScale) / 2, 20).scale(initialScale));

    //svg.attr('height', g.graph().height * initialScale + 40);
    // Run the renderer. This is what draws the final graph.

}
