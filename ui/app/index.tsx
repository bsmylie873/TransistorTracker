import {Text, View, Image} from "react-native";

export default function Index() {
    return (
        <View
            style={{
                flex: 1,
                justifyContent: "center",
                alignItems: "center",
            }}
        >
            <Image
                source={require("../assets/images/transistortrackerlogo.png")}
                style={{width: 200, height: 200}}
            />
            <Text style={{ fontWeight: "bold", fontSize: 24 }}>Transistor Tracker</Text>
        </View>
    );
}