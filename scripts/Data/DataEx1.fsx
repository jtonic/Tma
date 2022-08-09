
type Room =
    struct
        val Name: string
        val Description: string
        val Number: byte

        new (name, description, number) = { Name = name; Description = description; Number = number }
    end

let Room4 = Room (name = "Room 4", description = "Family Room", number = byte 4)
Room4
Room4.Name
Room4.Description
int Room4.Number
