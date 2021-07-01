from specklepy.api.client import SpeckleClient
from specklepy.api.credentials import get_default_account, get_local_accounts
from specklepy.transports.server import ServerTransport
from specklepy.api import operations

# Initialise the Speckle client pointing to your specific server.
client = SpeckleClient(host="https://speckle.xyz") 

# Get the default account
# If you have more than one account, or the account is not the default, use get_local_accounts
account = get_default_account()

# Authenticate using the account token
client.authenticate(token=account.token)

# Your account email
print('Welcome!!',account.userInfo.email, account.serverInfo.url)


# use that stream id to get the stream from the server
streamId = "42c06de34f"
branch = client.branch.get(streamId, "main", 1)
hash = branch.commits.items[0].referencedObject




# next create a server transport - this is the vehicle through which you will send and receive
transport = ServerTransport(client=client, stream_id=streamId)

# this receives the object back from the transport.
# the received data will be deserialised back into a `Block` 
received_base = operations.receive(obj_id=hash, remote_transport=transport)

for list in received_base["@data"]:
    for item in list:
        item.z += 1


# this serialises the modified points and sends it to the transport
hash = operations.send(base=received_base, transports=[transport])

# you can now create a commit on your stream with this object
commit_id = client.commit.create(
    stream_id=streamId,
    branch_name="python",
    object_id=hash, 
    message="Points were modified by AECTechDemo.py script",
    )

print("Successfully created commit with id:", commit_id)