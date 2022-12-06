import { QueryClient, QueryClientProvider } from "@tanstack/react-query";

import Routing from "./routes";
import Layout from "./components/layout/Layout";

const queryClient = new QueryClient();

const App = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <Layout>
        <Routing/>
      </Layout>
    </QueryClientProvider>
  );
};

export default App;