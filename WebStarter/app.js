let token = "096315ee1bf8c961444b270746becd1e8474baa79e"
let objUrl =
  "http://localhost:3000/streams/2d9b814ed6/objects/d679e6ff0efb8c9c102b8f8136b0f68a"
// Create the viewer instance
let viewer = new window.Speckle.Viewer({
  container: document.getElementById("viewer"),
  showStats: true
})

viewer.loadObject(objUrl, token)

viewer.interactions.zoomExtents(0.95, false)

viewer.on("select", objects => {
  console.info(`Selection event. Current selection count: ${objects.length}.`)
  console.log(objects)
})

viewer.on("object-doubleclicked", obj => {
  console.info("Object double click event.")
  console.log(obj ? obj : "nothing was doubleckicked.")
})
